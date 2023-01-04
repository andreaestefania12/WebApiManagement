export interface Client {
    id: number;
    firstName: string;
    lastName: string;
    emailAddress: string;
    phoneNumber: string;
    status: string;
    registrationDate: string;
}

export interface ClientEdit {
    id: number;
    firstName: string;
    lastName: string;
    emailAddress: string;
    phoneNumber: string;
    status: string;
}