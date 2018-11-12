//import { Component, OnInit } from '@angular/core';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-templates',
  templateUrl: './templates.component.html',
  styleUrls: ['./templates.component.css']
})

//export class TemplatesComponent implements OnInit {
export class TemplatesComponent {
  public templates: NotificationTemplate[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<NotificationTemplate[]>(baseUrl + 'api/NotificationTemplates/GetTemplates').subscribe(result => {
      this.templates = result;
    }, error => console.error(error));
  
  //ngOnInit() { }
  }
}

interface NotificationTemplate
{
    id: number;
    name: string;
    body: string;
    createdDate: Date;
    isInactive: boolean;
}
