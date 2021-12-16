import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { take } from 'rxjs';
import { ConfigJson } from '../models/config-json';

@Injectable({
    providedIn: 'root',
  })
export class ConfigService {
  private _configuration!: ConfigJson;

  public get configJson(): ConfigJson {
    return this._configuration;
  }

  constructor(private httpClient: HttpClient) {}

  loadSettings() {
    this.httpClient.get<ConfigJson>('assets/config.json').pipe(take(1)).subscribe((s) => {
      this._configuration = s;
    });
  }
}

export function LoadConfigJson(configService: ConfigService) {
  return () => configService.loadSettings();
}
