import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { Project } from '../project';
@Component({
  selector: 'app-project-edit',
  templateUrl: './project-edit.component.html',
  styleUrls: ['./project-edit.component.css']
})
export class ProjectEditComponent implements OnInit {
  title: string = '';
  form: FormGroup = new FormGroup({});
  project: Project = new Project();
  id?: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
  }
  ngOnInit() {
    this.form = new FormGroup({
      id: new FormControl(''),
      code: new FormControl(''),
      name: new FormControl(''),
      client: new FormControl(''),
      revenue: new FormControl(''),
      startDateTime: new FormControl(''),
      endDateTime: new FormControl(''),
      status: new FormControl('')
    });
    this.loadData();
  }
  loadData() {
    this.id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    if (this.id) {
      // EDIT MODE
      var url = this.baseUrl + "/Projects/" + this.id;
      this.http.get<Project>(url).subscribe(result => {
        this.project = result;
        this.title = "Edit - " + this.project.name;
        this.form.patchValue(this.project);
      }, error => console.error(error));
    }
    else {
      // ADD NEW MODE
      this.title = "Create a new Project";
    }
  }
  onSubmit() {
    var project = (this.id) ? this.project : <Project>{};
    project.id = this.form.get("id")?.value;
    project.code = this.form.get("code")?.value;
    project.name = this.form.get("name")?.value;
    project.client = this.form.get("client")?.value;
    project.revenue = this.form.get("revenue")?.value;
    project.startDateTime = this.form.get("startDateTime")?.value;
    project.endDateTime = this.form.get("endDateTime")?.value;
    project.status = this.form.get("status")?.value;
    if (this.id) {
      // EDIT mode
      var url = this.baseUrl + "/Projects/" + this.project.id;
      this.http
        .put<Project>(url, project)
        .subscribe(result => {
          console.log("Project " + project.id + " has been updated.");
          this.router.navigate(['/projects']);
        }, error => console.error(error));
    }
    else {
      // ADD NEW mode
      var url = this.baseUrl + "/Projects";
      this.http
        .post<Project>(url, project)
        .subscribe(result => {
          console.log("Project " + result.id + " has been created.");
          this.router.navigate(['/projects']);
        }, error => console.error(error));
    }
  }
}
