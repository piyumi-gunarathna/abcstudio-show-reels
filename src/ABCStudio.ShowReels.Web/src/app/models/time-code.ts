export class TimeCode {
    constructor( 
        public hours: number,
        public minutes: number,
        public seconds:number,
        public frames: number,
        public framesPerSecond: number  
     ) {}

     public get TotalFrames(){
        return this.frames + (this.seconds + this.minutes * 60 + this.hours * 3600) * this.framesPerSecond;
    }

    public AddTimeCodes(timeCode: TimeCode): TimeCode
    {
        this.ValidateFrameReates(this, timeCode);

        var totalFrames = this.frames + timeCode.frames;
        var calculatedSeconds = Math.floor(totalFrames / this.framesPerSecond);
        var frames = totalFrames % this.framesPerSecond;

        var totalSeconds = this.seconds + timeCode.seconds + calculatedSeconds;
        var calculatedMinutes = Math.floor(totalSeconds / 60);
        var seconds = totalSeconds % 60;

        var totalMinutes = this.minutes + timeCode.minutes + calculatedMinutes;
        var calculatedHours = Math.floor(totalMinutes / 60);
        var minutes = totalMinutes % 60;

        var totalHours = this.hours + timeCode.hours + calculatedHours;

        return new TimeCode(totalHours, minutes, seconds, frames, this.framesPerSecond);
    }

    private ValidateFrameReates(a: TimeCode,b: TimeCode)
    {
        if (a.framesPerSecond != b.framesPerSecond)
        {
            throw new Error("Frames per seconds should be equal.");
        }
    }

    public get ToString() {
        return `${String(isNaN(this.hours)? 0: this.hours).padStart(2, "0")}
        :${String(isNaN(this.minutes)? 0: this.minutes).padStart(2, "0")}
        :${String(isNaN(this.seconds)? 0: this.seconds).padStart(2, "0")}
        :${String(isNaN(this.frames)? 0: this.frames).padStart(2, "0")}`;
    }
}
