import { Component, OnInit } from '@angular/core';
import { Device } from '../models/device.model';
import { DeviceService } from '../services/device.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.css']
})
export class DeviceListComponent implements OnInit {
  devices$?: Observable<Device[]>;

  constructor(private deviceService: DeviceService) { }

  ngOnInit(): void {
    this.devices$ = this.deviceService.getAllDevices();
   }
 }
