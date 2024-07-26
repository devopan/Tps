import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectsComponent } from './projects/projects.component';
import { TasksComponent } from './tasks/tasks.component';
import { ProjectEditComponent } from './projects/edit/project-edit.component';
import { TaskEditComponent } from './tasks/edit/task-edit.component';

const routes: Routes = [
  { path: '', component: ProjectsComponent, pathMatch: 'full' },
  { path: 'projectTasks', component: TasksComponent },
  { path: 'project/:id', component: ProjectEditComponent },
  { path: 'project', component: ProjectEditComponent },
  { path: 'projectTask/:id', component: TaskEditComponent },
  { path: 'projectTask', component: TaskEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
