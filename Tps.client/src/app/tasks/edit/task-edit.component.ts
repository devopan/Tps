import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { Task } from '../task';
import { TaskData } from 'zone.js/lib/zone-impl';
@Component({
  selector: 'app-task-edit',
  templateUrl: './task-edit.component.html',
  styleUrls: ['./task-edit.component.css']
})
export class TaskEditComponent implements OnInit {
  title: string = '';
  form: FormGroup = new FormGroup({});
  task: Task = new Task();
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
      jobName: new FormControl(''),
      service: new FormControl(''),
      volumePages: new FormControl(''),
      rate: new FormControl(''),
      total: new FormControl(''),
      marginPercent: new FormControl(''),
      startDateTime: new FormControl(''),
      endDateTime: new FormControl(''),
      status: new FormControl(''),
      projectId: new FormControl(''),
      translatorId: new FormControl('')
    });
    this.loadData();
  }
  loadData() {
    // retrieve the ID from the 'id'
    this.id = Number(this.activatedRoute.snapshot.paramMap.get('id'));
    if (this.id) {
      // EDIT MODE
      var url = this.baseUrl + "/Tasks/" + this.id;
      this.http.get<Task>(url).subscribe(result => {
        this.task = result;
        this.title = "Edit - " + this.task.jobName;
        this.form.patchValue(this.task);
      }, error => console.error(error));
    }
    else {
      // ADD NEW MODE
      this.title = "Create a new Task";
    }
  }
  onSubmit() {
    var task = (this.id) ? this.task : <Task>{};
    task.id = this.form.get("id")?.value;
    task.code = this.form.get("code")?.value;
    task.jobName = this.form.get("jobName")?.value;
    task.service = this.form.get("service")?.value;
    task.volumePages = this.form.get("volumePages")?.value;
    task.rate = this.form.get("rate")?.value;
    task.total = this.form.get("total")?.value;
    task.marginPercent = this.form.get("marginPercent")?.value;
    task.startDateTime = this.form.get("startDateTime")?.value;
    task.endDateTime = this.form.get("endDateTime")?.value;
    task.status = this.form.get("status")?.value;
    task.projectId = this.form.get("projectId")?.value;
    task.translatorId = this.form.get("translatorId")?.value;
    var url = this.baseUrl + "/Tasks/" + this.task.id;
    if (this.id) {
      // EDIT mode
      var url = this.baseUrl + "/Tasks/" + this.task.id;
      this.http
        .put<Task>(url, task)
        .subscribe(result => {
          console.log("Task " + task.id + " has been updated.");
          this.router.navigate(['/projectTasks']);
        }, error => console.error(error));
    }
    else {
      // ADD NEW mode
      var url = this.baseUrl + "/Tasks";
      this.http
        .post<Task>(url, task)
        .subscribe(result => {
          console.log("Task " + result.id + " has been created.");
          this.router.navigate(['/projectTasks']);
        }, error => console.error(error));
    }
  }
}
