export interface Institution {
    id: number;
    institution: string;
    faculty?: string;
    startDate: string;
    endDate?: string;
    progress: string;
    isCurrentlyStudying: boolean;
}