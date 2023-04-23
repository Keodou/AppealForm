import { Contact } from "./contact";

export interface Message {
    id?: number;
    text: string;
    //contactId?: number;
    topicId?: number
    contact: Contact;
}