import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormsModule, Form, NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { DataService, Brand } from '../data.service';
import { HttpClient } from '@angular/common/http';
import { fillProperties } from '@angular/core/src/util/property';



@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {
  @Input() textlen: number;
  @Input() brandid: number;
  messageForm: FormGroup;
  messageTest: Form;
  submitted = false;
  success = false;
  test = false;

  isValidFormSubmitted = false;
  Brand: Brand;

  constructor(private formBuilder: FormBuilder, private data: DataService) { }

  ngOnInit() {
    this.messageForm = this.formBuilder.group({
      bID: ['', Validators.required],
      bName: ['', Validators.required, Validators.maxLength(30)]
    });
    
  }

  onSubmit() {
    this.submitted = true;

    if (this.messageForm.invalid) {
        return;
    }

    this.success = true;
    
  }

  isNumber(val) { 
  
    
  }


  onTest(brand : Brand, form: NgForm, textlen: number) {
    this.isValidFormSubmitted = false;
    
     if (form.invalid || textlen > 30) {

        return;
     }
     this.isValidFormSubmitted = true;
    this.data.setBrand(brand).subscribe(brand=> {
      (JSON.stringify(brand))
    });
  }
  

  

    

}
