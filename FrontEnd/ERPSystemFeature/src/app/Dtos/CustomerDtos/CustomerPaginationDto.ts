import { IReadCustomerDto } from './IReadCustomerDto';

export interface CustomerPaginationDto {
  customerDtos: IReadCustomerDto[];
  totalCount: number;
}
