import { Contact } from "./contact";

export interface Message {
    id?: number;
    text: string;
    contactName: string;
    contactEmail: string;
    contactPhone: string;
    //contactId?: number;
    topicId?: number;
    //contact: Contact;
}