import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Estado } from '../models/Estado';
import { Municipio } from '../models/Municipio';
import { DialogService } from '../services/dialog.service';
import { EstadoService } from '../services/estado.service';
import { MessageService } from '../services/message.service';
import { MunicipioService } from '../services/municipio.service';

@Component({
  selector: 'app-estado',
  templateUrl: './estado.component.html',
  styleUrls: ['./estado.component.css']
})
export class EstadoComponent implements OnInit {

  public tituloEstado = 'Estados';
  public estadoSelected: Estado = new Estado();
  public modalRef: BsModalRef = new BsModalRef;
  public municipios: Municipio[] = [];


  estadoForm = new FormGroup({
    id: new FormControl(''),
    nome: new FormControl(''),
    sigla: new FormControl('')
  });

  public estados: Estado[] = [];

  constructor(private fb: FormBuilder, 
              private modalService: BsModalService,
              private estadoServico: EstadoService,
              private dialogoServico: DialogService,
              private messageService: MessageService,
              private municipioServico: MunicipioService) {
    this.createForm(); 
  }

  createForm() {
    this.estadoForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      sigla: ['', Validators.required]
    });
  }

  openModal(template: TemplateRef<any>, estadoId: number) {
    this.modalRef = this.modalService.show(template);

    this.carregarMunicipiosPeloEstadoId(estadoId);
  }

  ngOnInit(): void {
    this.carregarEstados();
  }

  carregarEstados() {
    this.estadoServico.obterTodos().subscribe(
      (resultado: Estado[]) => {
        this.estados = resultado;
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  estadoSelect(estado: Estado) {
    this.estadoSelected = estado;
    this.estadoForm.patchValue(estado);
  }

  novoEstado() {
    this.estadoSelected = new Estado();
    this.estadoSelected.id = -1;
    this.estadoForm.patchValue(this.estadoSelected);
  }

  salvarEstado(estado: Estado) {
    if (this.estadoSelected.id === -1) {
      estado.id = 0;
      this.estadoServico.salvar(estado).subscribe(
        (resultado: any) => {
          this.carregarEstados();
        },
        (erro: any) => {
          console.log(erro);
        }
      )
    } else {
      this.estadoServico.editar(estado).subscribe(
        (resultado: any) => {
          this.carregarEstados();
        },
        (erro: any) => {
          console.log(erro);
        }
      )
    }
    this.estadoSelected.id = 0;
  }

  public exibirMensagemAoASalvar() {
    this.messageService.abrir();
  }

  public abrirDialogoDeConfirmacao(estado: Estado) {
    this.dialogoServico
      .confirmar()
      .then(
        (confirmou) => this.excluirEstado(estado, confirmou)
      )
      .catch(
        (erro: any) => console.log(erro)
      );
  }

  excluirEstado(estado: Estado, confirmado: boolean) {
    if (confirmado) {
      this.estadoServico.deletar(estado.id).subscribe(
        (retorno: any) => {
          this.carregarEstados();
        },
        (erro: any) => {
          console.log(erro);
        }
      )
    }
  }

  onSubmit() {
    this.salvarEstado(this.estadoForm.value);
    this.exibirMensagemAoASalvar();
  }

  voltar() {
    this.estadoSelected = new Estado();
  }

  carregarMunicipiosPeloEstadoId(estadoId: number) {
    this.municipioServico.obterTodosPeloEstadoId(estadoId).subscribe(
      (resultado: Municipio[]) => {
        this.municipios = resultado;
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

}
