


import { Component, OnInit, TemplateRef } from '@angular/core';
import { AxiosInterceptorManager } from 'axios';

import { EventoService } from '@app/services/evento.service';
import { Evento } from '@app/models/Evento';

import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {

  modalRef?: BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  widthImg: number = 80;
  marginImg: number = 2;
  isCollapsed: boolean = false;

  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf( filtrarPor) !== -1 || evento.local.toLocaleLowerCase().indexOf( filtrarPor) !== -1
    )
  }


  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastrService: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router

    ) { }

 public ngOnInit(): void {
    this.getEventos();
    /** spinner starts on init */
    this.spinner.show();

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 5000);
  }

  /* public alterarImagem(){
    this.exibirImagem = !this.exibirImagem;
  } */

  public getEventos(): void {

    this.eventoService.getEventos().subscribe({
      next: (_evento: Evento[]) => {
        this.eventos = _evento;
        this.eventosFiltrados = this.eventos;
      },
      error: (error:any) => console.log(error),
      complete: () => this.spinner.hide()
  });



  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {

    this.modalRef?.hide();
    this.toastrService.success('O evento foi excluido com sucesso', 'Excluido!');
  }

  decline(): void {

    this.modalRef?.hide();
  }

  detalheEvento(id: number): void {
    this.router.navigate([`eventos/detalhe/${id}`]);
  }

}
