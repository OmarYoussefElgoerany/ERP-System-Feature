export interface AddCallsDto {
  callTitle: string;
  project: string;
  employeeName: string | null;
  callType: string | null;
  date: string | null;
  isDone: boolean | null;
  customerId: number | null;
}
