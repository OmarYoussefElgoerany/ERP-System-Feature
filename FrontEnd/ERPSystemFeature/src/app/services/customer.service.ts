import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerPaginationDto } from '../Dtos/CustomerDtos/CustomerPaginationDto';
import { environment } from '../enviroments/environment';
import { IReadCustomerDto } from '../Dtos/CustomerDtos/IReadCustomerDto';
import { IAddCustomerDto } from '../Dtos/CustomerDtos/IAddCustomerDto';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  constructor(private httpClient: HttpClient) {}
  apiUrl = `${environment.apiUrl}/Customer`;
  public GetAllWithPagi(
    page: number,
    countPerPage: number
  ): Observable<CustomerPaginationDto> {
    const apiUrl = `${environment.apiUrl}/Customer/${page}/${countPerPage}`;
    return this.httpClient.get<CustomerPaginationDto>(apiUrl);
  }
  public Edit(custmr: IReadCustomerDto): Observable<IReadCustomerDto> {
    return this.httpClient.put<IReadCustomerDto>(
      `${environment.apiUrl}/Customer`,
      custmr
    );
  }
  public GetById(id: number): Observable<IReadCustomerDto> {
    return this.httpClient.get<IReadCustomerDto>(`${this.apiUrl}/${id}`);
  }
  public Delete(id: number): Observable<IReadCustomerDto> {
    return this.httpClient.delete<IReadCustomerDto>(`${this.apiUrl}/${id}`);
  }
  public GetAll(): Observable<IReadCustomerDto[]> {
    return this.httpClient.get<IReadCustomerDto[]>(this.apiUrl);
  }
  public Add(customer: IAddCustomerDto): Observable<IAddCustomerDto> {
    return this.httpClient.post<IAddCustomerDto>(this.apiUrl, customer);
  }
}
