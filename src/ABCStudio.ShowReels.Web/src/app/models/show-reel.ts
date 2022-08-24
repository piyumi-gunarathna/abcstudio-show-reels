import { VideoClip } from "./video-clip";

export class ShowReel {
    constructor( 
        public name: string,
        public description: string,
        public videoDefinition: number,
        public videoStandard: number,
        public videoClips: VideoClip[]   
     ) {}
}