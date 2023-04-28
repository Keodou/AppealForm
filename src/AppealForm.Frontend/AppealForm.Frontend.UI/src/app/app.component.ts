import { Component } from '@angular/core';
import { Message } from './models/message';
import { MessageService } from './services/message.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [MessageService]
})
export class AppComponent {
  title = 'AppealForm.Frontend.UI';
  message: Message = {
    contactName: '',
    contactEmail: '',
    contactPhone: '',
    topicName: '',
    text: '',
  };
  formData: FormData = new FormData();
  savedMessage: any;
  showForm: boolean = true;
  captchaResolved = false;

  constructor(private messageService: MessageService) { }

  resolved(captchaResponse: string) {
    this.captchaResolved = true;
  }

  onSubmit() {
    this.messageService.createMessage(this.message).subscribe((response: any) => {
      console.log("message added successfully");
      this.savedMessage = response;
      this.formData = new FormData();
      this.showForm = false;
    });
  }
}
