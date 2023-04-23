import { Message } from "./message";

export interface Contact {
    id?: number;
    name: string;
    email: string;
    phone: string;
    messages: Message[];
}