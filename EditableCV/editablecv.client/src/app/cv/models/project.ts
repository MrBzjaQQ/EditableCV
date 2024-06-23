export interface IProject {
    id: number;
    projectName: string;
    projectUrl?: string | null;
    repositoryUrl?: string | null;
    imageUrl?: string | null;
}