import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  { path: "items-list", loadChildren: () => import('./modules/items-list/items-list.module').then(m => m.ItemsListModule)},
  { path: '**', redirectTo: "items-list", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { enableTracing: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
