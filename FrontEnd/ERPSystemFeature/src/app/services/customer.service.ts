import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerPaginationDto } from '../Dtos/CustomerDtos/CustomerPaginationDto';
import { environment } from '../enviroments/environment';
import { IReadCustomerDto } from '../Dtos/CustomerDtos/IReadCustomerDto';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  constructor(private httpClient: HttpClient) {}

  public GetAllWithPagi(
    page: number,
    countPerPage: number
  ): Observable<CustomerPaginationDto> {
    const apiUrl = `${environment.apiUrl}/Customer/${page}/${countPerPage}`;
    return this.httpClient.get<CustomerPaginationDto>(apiUrl);
  }

  public GetAll(): Observable<IReadCustomerDto[]> {
    const apiUrl = `${environment.apiUrl}/Customer`;
    return this.httpClient.get<IReadCustomerDto[]>(apiUrl);
  }
}
