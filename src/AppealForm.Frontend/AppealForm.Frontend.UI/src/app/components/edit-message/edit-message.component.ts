import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Message } from 'src/app/models/message';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-edit-message',
  templateUrl: './edit-message.component.html',
  styleUrls: ['./edit-message.component.css']
})
export class EditMessageComponent implements OnInit {
  @Input() message?: Message;
  @Output() messagesUpdated = new EventEmitter<Message[]>();

  constructor(private messageService: MessageService) { }

  ngOnInit(): void {

  }
  createMessage(message: Message) {
    this.messageService
      .createMessage(message)
      .subscribe((messages: Message[]) => this.messagesUpdated.emit(messages));
  }
}
