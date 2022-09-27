import { IAddress } from "./iaddress";

export interface ICustomer {
    id: number,
    firstName: string,
    lastName: string,
    email: string,
    phoneNumber: string,
    Addresses: IAddress[] | null,
    CustomersProducts: number[] | null
}