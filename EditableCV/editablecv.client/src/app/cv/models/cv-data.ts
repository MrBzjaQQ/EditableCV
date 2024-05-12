import { CommonInfo } from "./common-info";
import { ContactInfo } from "./contact-info";
import { Institution } from "./institution";
import { Skill } from "./skill";
import { WorkPlace } from "./work-place";

export interface CvData {
    commonInfo?: CommonInfo;
    contactInfo?: ContactInfo[];
    workPlaces?: WorkPlace[];
    education?: Institution[];
    skills?: Skill[];
}