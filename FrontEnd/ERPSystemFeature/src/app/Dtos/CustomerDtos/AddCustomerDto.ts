export interface AddCustomerDto {
  name: string;
  job: string;
  address: string | null;
  residance: string | null;
  mobile: number;
  whatsapp: number | null;
  nationality: string | null;
  dateAdded: string | null;
  lastEdit: string | null;
  customerRating: string | null;
  employeeId: number | null;
}
