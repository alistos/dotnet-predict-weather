import { Injectable } from '@angular/core';
import { AddDeviceRequest } from '../models/add-device-request-model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Device } from '../models/device.model';
import { environment } from 'src/environments/environment';
import { EditDeviceRequest } from '../models/edit-device-request.model';

@Injectable({
  providedIn: 'root'
})
export class DeviceService {

  constructor(private http: HttpClient) { }

  addDevice(model: AddDeviceRequest): Observable<void> {
    model.commands = model.commands.replace(" ", "");
    var commands = model.commands.split(",");
    return this.http.post<void>(`${environment.apiBaseUrl}/api/device`, { manufacturer: model.manufacturer, commands: commands, url: model.url })  
  }

  getAllDevices(): Observable<Device[]> {
    return this.http.get<Device[]>(`${ environment.apiBaseUrl }/api/device`);
  }

  getDeviceById(id: string): Observable<Device> {
    return this.http.get<Device>(`${environment.apiBaseUrl}/api/device/${id}`);
  }

  editDevice(id: string, editDeviceRequest: EditDeviceRequest): Observable<Device> {
    editDeviceRequest.commands = editDeviceRequest.commands.replace(" ", "");
    var commands = editDeviceRequest.commands.split(",");
    return this.http.put<Device>(`${environment.apiBaseUrl}/api/device/${id}`, { manufacturer: editDeviceRequest.manufacturer, commands: commands, url: editDeviceRequest.url });
  }

  deleteDevice(id: string): Observable<Device> {
    return this.http.delete<Device>(`${environment.apiBaseUrl}/api/device/${id}`);
  }
}
