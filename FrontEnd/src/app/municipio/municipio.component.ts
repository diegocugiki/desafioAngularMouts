import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Estado } from '../models/Estado';
import { Municipio } from '../models/Municipio';
import { DialogService } from '../services/dialog.service';
import { EstadoService } from '../services/estado.service';
import { MessageService } from '../services/message.service';
import { MunicipioService } from '../services/municipio.service';

@Component({
  selector: 'app-municipio',
  templateUrl: './municipio.component.html',
  styleUrls: ['./municipio.component.css']
})
export class MunicipioComponent implements OnInit {

  public titulo = 'Municípios';
  public municipioSelected = new Municipio();
  public municipios: Municipio[] = [];
  public estados: Estado[] = [];

  public municipioForm = new FormGroup({
    id: new FormControl(''),
    nome: new FormControl(''),
    prefeito: new FormControl(''),
    populacao: new FormControl(''),
    estadoId: new FormControl('')
  });

  constructor(private fb: FormBuilder,
              private municipioServico: MunicipioService,
              private estadoServico: EstadoService,
              private dialogoServico: DialogService,
              private messageService: MessageService) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarMunicipios();
    this.carregarEstados();
  }

  criarForm() {
    this.municipioForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      prefeito: [''],
      populacao: [''],
      estadoId: ['', Validators.required]
    });
  }

  carregarMunicipios() {
    this.municipioServico.obterTodos().subscribe(
      (resultado: Municipio[]) => {
        this.municipios = resultado;
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  carregarEstados() {
    this.estadoServico.obterTodos().subscribe(
      (resultado: Estado[]) => {
        this.estados = resultado;
      },
      (erro: any) => {
        console.log(erro);
      }
    )
  }

  municipioSelect(municipio: Municipio) {
    this.municipioSelected = municipio;
    this.municipioForm.patchValue(municipio);
  }

  novoMunicipio() {
    this.municipioSelected = new Municipio();
    this.municipioSelected.id = -1;
    this.municipioForm.patchValue(this.municipioSelected);
  }

  salvarMunicipio(municipio: Municipio) {
    if (this.municipioSelected.id === -1) {
      municipio.id = 0;
      this.municipioServico.salvar(municipio).subscribe(
        (resultado: any) => {
          console.log(resultado);
          this.carregarMunicipios();
        },
        (erro: any) => {
          console.log(erro);
        }
      )
    } else {
      this.municipioServico.editar(municipio).subscribe(
        (resultado: any) => {
          console.log(resultado);
          this.carregarMunicipios();
        },
        (erro: any) => {
          console.log(erro);
        }
      )
    }
    this.municipioSelected.id = 0;
  }

  public exibirMensagemAoASalvar() {
    this.messageService.abrir();
  }

  public abrirDialogoDeConfirmacao(municipio: Municipio) {
    this.dialogoServico
      .confirmar()
      .then(
        (confirmou) => this.excluirMunicipio(municipio, confirmou)
      )
      .catch(
        (erro: any) => console.log(erro)
      );
  }

  excluirMunicipio(municipio: Municipio, confirmado: boolean) {
    if (confirmado) {
      this.municipioServico.deletar(municipio.id).subscribe(
        (retorno: any) => {
          console.log(retorno);
          this.carregarMunicipios();
        },
        (erro: any) => {
          console.log(erro);
        }
      );
    }
  }

  onSubmit() {
    this.salvarMunicipio(this.municipioForm.value);
    this.exibirMensagemAoASalvar();
  }

  voltar() {
    this.municipioSelected = new Municipio();
  }

}
