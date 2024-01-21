import {
  Component,
  ElementRef,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { CustomerService } from '../services/customer.service';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { IReadCustomerDto } from '../Dtos/CustomerDtos/IReadCustomerDto';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { ActivatedRoute } from '@angular/router';
import * as xls from 'xlsx';
@Component({
  selector: 'app-customertable',
  templateUrl: './customertable.component.html',
  styleUrl: './customertable.component.css',
})
export class CustomertableComponent implements OnInit {
  @ViewChild(MatTable) table!: MatTable<any>;
  @ViewChild(MatPaginator)
  paginator?: MatPaginator;
  dataSource: any;
  length = 500;
  pageSize = 10;
  pageIndex = 0;
  pageSizeOptions = [5, 10, 25];
  showFirstLastButtons = true;
  isLoaded: boolean = false;
  displayedColumns: string[] = [
    'id',
    'name',
    'job',
    'address',
    'residance',
    'mobile',
    'whatsapp',
    'nationality',
    'dateAdded',
    'lastEdit',
    'customerRating',
    'edit',
    'delete',
  ];
  forCheckedCol = this.displayedColumns;
  selectedColumns: string[] = [];

  constructor(
    private customerService: CustomerService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.customerService.GetAll().subscribe((data) => {
      this.dataSource = new MatTableDataSource<IReadCustomerDto>(data);
      this.isLoaded = true;
      this.dataSource.paginator = this.paginator;
    });
  }
  public refreshPage(e: Event) {
    e.preventDefault;
    this.customerService.GetAll().subscribe((data) => {
      this.dataSource.data = data;
    });
    console.log('Button clicked!');
  }
  private handleInputDataChange() {
    this.displayedColumns = this.selectedColumns;
  }

  onDelete(customerId: number) {
    this.customerService.Delete(customerId).subscribe();
  }
  onCheckboxChange(column: string, event: Event) {
    const isChecked = (event.target as HTMLInputElement).checked;

    if (isChecked) {
      this.selectedColumns.push(column);
    } else {
      const index = this.selectedColumns.indexOf(column);
      if (index !== -1) {
        this.selectedColumns.splice(index, 1);
      }
    }
    this.handleInputDataChange();
  }

  handlePageEvent(event: PageEvent) {
    this.length = event.length;
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;
  }

  filterInput(input: HTMLInputElement) {
    let inputValue = input.value.trim().toLocaleLowerCase();
    this.findCustomer(inputValue);
  }
  findCustomer(inputValue: string) {
    this.dataSource.filter = inputValue;
  }
  convertToExcel(): void {
    const dataToExport = this.dataSource.data.map((item: any) => {
      const exportItem: any = {};
      this.displayedColumns.forEach((column: any) => {
        exportItem[column] = item[column];
      });
      return exportItem;
    });

    const ws: xls.WorkSheet = xls.utils.json_to_sheet(dataToExport);
    const wb: xls.WorkBook = xls.utils.book_new();
    xls.utils.book_append_sheet(wb, ws, 'Sheet1');
    xls.writeFile(wb, 'customers.xlsx');
  }
}
