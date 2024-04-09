import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { AppRoutingModule } from './app-routing.module';
import { DeviceListComponent } from './features/device/device-list/device-list.component';
import { AddDeviceComponent } from './features/device/add-device/add-device.component';
import { FormsModule } from '@angular/forms';
import { EditDeviceComponent } from './features/device/edit-device/edit-device.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    DeviceListComponent,
    AddDeviceComponent,
    EditDeviceComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
