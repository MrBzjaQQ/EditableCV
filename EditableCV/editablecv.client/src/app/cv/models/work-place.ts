export interface WorkPlace {
    id: number;
    companyName: string;
    position: string;
    experience?: string;
    startWorkingDate: string; // Date
    endWorkingDate?: string; // Date
    isCurrentlyWorking: boolean;
    webSite?: string,
    logoUrl?: string
}