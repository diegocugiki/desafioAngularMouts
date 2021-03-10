import { Injectable } from '@angular/core';
import { MessageComponent } from '../message/message.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor(private modalService: NgbModal) { }

  public abrir() {
      const modalRef = this.modalService.open(MessageComponent);
  }
}
