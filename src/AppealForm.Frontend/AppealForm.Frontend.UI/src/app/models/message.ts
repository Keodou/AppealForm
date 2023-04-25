import { Contact } from "./contact";

export interface Message {
    //id?: number;
    contactName: string;
    contactEmail: string;
    contactPhone: string;
    //contactId?: number;
    topicName: string;
    text: string;
    //contact: Contact;
}