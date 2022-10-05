import { FormGroup, FormBuilder, Validators, AbstractControlOptions } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-Perfil',
  templateUrl: './Perfil.component.html',
  styleUrls: ['./Perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form: FormGroup;

  get f(): any {
    return this.form.controls;
  }


  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

 public validation(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('senha', 'confirmeSenha')
    };

    this.form = this.fb.group( {
      titulo: ['', Validators.required],
      primeiroNome: ['', Validators.required],
      ultimoNome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', Validators.required],
      funcao: ['', Validators.required],
      descricao: ['', Validators.required],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confirmeSenha: ['', [Validators.required ]]


    }, formOptions );

  }

  public resetForm(): void{
    this.form.reset();
  }

}
