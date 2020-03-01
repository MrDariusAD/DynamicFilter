import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  { path: "items-list", loadChildren: () => import('./modules/items-list/items-list.module').then(m => m.ItemsListModule)},
  { path: "assistant", loadChildren: () => import('./modules/assistant/assistant.module').then(m => m.AssistantModule)},
  //{ path: '**', redirectTo: "items-list", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
