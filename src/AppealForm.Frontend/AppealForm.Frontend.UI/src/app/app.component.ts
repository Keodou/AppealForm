import { Component } from '@angular/core';
import { Message } from './models/message';
import { MessageService } from './services/message.service';
//import { ContactService } from './services/contact.service';
//import { Contact } from './models/contact';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [MessageService]
})
export class AppComponent {
  title = 'AppealForm.Frontend.UI';
  //messages: Message[] = [];
  //contacts: Contact[] = [];
  //messageToEdit?: Message;
  message: Message = {
    contactName: '',
    contactEmail: '',
    contactPhone: '',
    topicName: '',
    text: '',
  };

  constructor(private messageService: MessageService) { }

  onSubmit() {
    this.messageService.createMessage(this.message).subscribe(() => console.log("message added successfully"));
  }
  /*ngOnInit() : void {
    /*this.messageService
      .getMessages().subscribe((result: Message[]) => (this.messages = result));
    /*this.contactService
      .getContacts().subscribe((result: Contact[]) => (this.contacts = result));
  }*/

  /*updateMessageList(messages: Message[]) {
    this.messages = messages;
  }*/

  /*initMessage() {
    //this.messageToEdit = new Message();
  }*/
}
