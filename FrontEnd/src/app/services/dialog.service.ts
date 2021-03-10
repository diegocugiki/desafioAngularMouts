import { Injectable } from '@angular/core';
import { DialogComponent } from '../dialog/dialog.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

  constructor(private modalService: NgbModal) { }

  public confirmar(): Promise<boolean> {
      const modalRef = this.modalService.open(DialogComponent);

      return modalRef.result;
  }
}
