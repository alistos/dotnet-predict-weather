import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeviceListComponent } from './features/device/device-list/device-list.component';
import { AddDeviceComponent } from './features/device/add-device/add-device.component';

const routes: Routes = [
  {
    path: 'usermenu/device',
    component: DeviceListComponent,
  },
  {
    path: 'usermenu/device/add',
    component: AddDeviceComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
