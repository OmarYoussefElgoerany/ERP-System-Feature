import { ReadCallsDto } from '../CallsDtos/ReadCallsDto';

export interface CallsPaginationDto {
  readCallsDto: ReadCallsDto[];
  count: number;
}
