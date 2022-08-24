import { TimeCode } from "./time-code";

export class VideoClip {
    constructor(
        public name: string,
        public description: string,
        public videoDefinition: number,
        public videoStandard: number,
        public startTimeCode: TimeCode,
        public endTimeCode: TimeCode
    ) {}
}
