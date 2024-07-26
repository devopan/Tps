export class Task {
  public id: number = 0;
  public code: string = '';
  public jobName: string = '';
  public service: string = '';
  public volumePages: number = 0;
  public rate: number = 0;
  public total: number = 0;
  public marginPercent: number = 0;
  public startDateTime: string = '';
  public endDateTime: string = '';
  public status: boolean = false;
  public projectId: number = 0;
  public translatorId: number = 0;

  constructor() {}
}
