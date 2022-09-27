import { IAddress } from "./iaddress";

export interface ICustomer {
    id: number,
    firstName: string,
    lastName: string,
    email: string,
    phoneNumber: string,
    addresses: IAddress[] | null,
    CustomersProducts: number[] | null
}