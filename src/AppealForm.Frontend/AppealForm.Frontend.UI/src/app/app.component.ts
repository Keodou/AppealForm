import { Component } from '@angular/core';
import { Message } from './models/message';
import { MessageService } from './services/message.service';
import { ContactService } from './services/contact.service';
import { Contact } from './models/contact';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AppealForm.Frontend.UI';
  messages: Message[] = [];
  contacts: Contact[] = [];
  messageToEdit?: Message;

  constructor(private messageService: MessageService, private contactService: ContactService) { }

  ngOnInit() : void {
    this.messageService
      .getMessages().subscribe((result: Message[]) => (this.messages = result));
    /*this.contactService
      .getContacts().subscribe((result: Contact[]) => (this.contacts = result));*/
  }

  updateMessageList(messages: Message[]) {
    this.messages = messages;
  }

  initMessage() {
    //this.messageToEdit = new Message();
  }
}
