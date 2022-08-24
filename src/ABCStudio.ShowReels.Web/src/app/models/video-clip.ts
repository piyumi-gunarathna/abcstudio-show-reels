import { TimeCode } from "./time-code";

export class VideoClip {
    constructor(
        public name: string,
        public description: string,
        public definition: number,
        public standard: number,
        public startTimeCode: TimeCode,
        public endTimeCode: TimeCode
    ) {}
}
