import { Injectable } from '@angular/core';
import { Message } from '../models/message';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor() { }

  public getMessages() : Message[] {
    let message = new Message;
    message.id = 1;
    message.text = "Новая запись на ангуляре";
    message.contactId = 1;
    message.topicId = 1;

    return [message];
  }
}
