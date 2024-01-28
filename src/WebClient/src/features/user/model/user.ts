export type User = {
    id: string;
    email: string;
    password: string;
    firstName?: string;
    lastName?: string;
    dateOfBirth?: Date;
    createdBy: string;
    created?: Date;
    lastModifiedBy?: string;
    lastModified: Date;
};
