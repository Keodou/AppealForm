import { Component } from '@angular/core';
import { Message } from './models/message';
import { MessageService } from './services/message.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AppealForm.Frontend.UI';
  messages: Message[] = [];

  constructor(private messageService: MessageService) { }

  ngOnInit() : void {
    this.messages = this.messageService.getMessages();
    console.log(this.messages);
  }
}
