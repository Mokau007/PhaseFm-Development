import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminPortalRoutingModule } from './admin-portal-routing.module';
import { PortalNavComponent } from './Core/portal-nav/portal-nav.component';
import { EcommerceDashboardComponent } from './Features/dashboard/ecommerce-dashboard/ecommerce-dashboard.component';
import { RadioDashboardComponent } from './Features/dashboard/radio-dashboard/radio-dashboard.component';
import { DiscountComponent } from './Features/ecommerce-subsystem/discount/discount.component';
import { VatComponent } from './Features/ecommerce-subsystem/vat/vat.component';
import { DeliveryComponent } from './Features/ecommerce-subsystem/delivery/delivery.component';
import { AddColorComponent } from './Features/ecommerce-subsystem/product-management/crud-colors/add-color/add-color.component';
import { ViewColorsComponent } from './Features/ecommerce-subsystem/product-management/crud-colors/view-colors/view-colors.component';
import { DeleteColorsComponent } from './Features/ecommerce-subsystem/product-management/crud-colors/delete-colors/delete-colors.component';
import { EditColorComponent } from './Features/ecommerce-subsystem/product-management/crud-colors/edit-color/edit-color.component';
import { AddProductComponent } from './Features/ecommerce-subsystem/product-management/crud-product/add-product/add-product.component';
import { EditProductComponent } from './Features/ecommerce-subsystem/product-management/crud-product/edit-product/edit-product.component';
import { DeleteProductComponent } from './Features/ecommerce-subsystem/product-management/crud-product/delete-product/delete-product.component';
import { ViewProductsComponent } from './Features/ecommerce-subsystem/product-management/crud-product/view-products/view-products.component';
import { ViewProductCategoryComponent } from './Features/ecommerce-subsystem/product-management/crud-product-category/view-product-category/view-product-category.component';
import { EditProductCategoryComponent } from './Features/ecommerce-subsystem/product-management/crud-product-category/edit-product-category/edit-product-category.component';
import { AddProductCategoryComponent } from './Features/ecommerce-subsystem/product-management/crud-product-category/add-product-category/add-product-category.component';
import { DeleteProductCategoryComponent } from './Features/ecommerce-subsystem/product-management/crud-product-category/delete-product-category/delete-product-category.component';
import { AddProductTypeComponent } from './Features/ecommerce-subsystem/product-management/crud-product-type/add-product-type/add-product-type.component';
import { EditProductTypeComponent } from './Features/ecommerce-subsystem/product-management/crud-product-type/edit-product-type/edit-product-type.component';
import { DeleteProductTypeComponent } from './Features/ecommerce-subsystem/product-management/crud-product-type/delete-product-type/delete-product-type.component';
import { ViewProductTypesComponent } from './Features/ecommerce-subsystem/product-management/crud-product-type/view-product-types/view-product-types.component';
import { ViewSizesComponent } from './Features/ecommerce-subsystem/product-management/crud-sizes/view-sizes/view-sizes.component';
import { AddSizeComponent } from './Features/ecommerce-subsystem/product-management/crud-sizes/add-size/add-size.component';
import { EditSizeComponent } from './Features/ecommerce-subsystem/product-management/crud-sizes/edit-size/edit-size.component';
import { DeleteSizeComponent } from './Features/ecommerce-subsystem/product-management/crud-sizes/delete-size/delete-size.component';
import { ViewClientsComponent } from './Features/ecommerce-subsystem/client-management/view-clients/view-clients.component';
import { PendingOrdersComponent } from './Features/ecommerce-subsystem/client-management/pending-orders/pending-orders.component';
import { CompleteOrderComponent } from './Features/ecommerce-subsystem/client-management/complete-order/complete-order.component';
import { OrderHistoryComponent } from './Features/ecommerce-subsystem/client-management/order-history/order-history.component';
import { DeliverOrderComponent } from './Features/ecommerce-subsystem/client-management/deliver-order/deliver-order.component';
import { ViewProfileComponent } from './Features/profile-management/view-profile/view-profile.component';
import { UpdateProfileComponent } from './Features/profile-management/update-profile/update-profile.component';
import { ViewUsersComponent } from './Features/account-management/view-users/view-users.component';
import { AddUserComponent } from './Features/account-management/add-user/add-user.component';
import { EditUserComponent } from './Features/account-management/edit-user/edit-user.component';
import { DeleteUserComponent } from './Features/account-management/delete-user/delete-user.component';
import { CrudEventComponent } from './Features/radio-subsystem/crud-event/crud-event.component';
import { CrudShowComponent } from './Features/radio-subsystem/crud-show/crud-show.component';
import { ViewMusicSubmissionComponent } from './Features/radio-subsystem/music-submission/view-music-submission/view-music-submission.component';
import { ApproveMusicSubmissionComponent } from './Features/radio-subsystem/music-submission/approve-music-submission/approve-music-submission.component';
import { RejectMusicSubmissionComponent } from './Features/radio-subsystem/music-submission/reject-music-submission/reject-music-submission.component';
import { ViewSongRequestsComponent } from './Features/radio-subsystem/song-requests/view-song-requests/view-song-requests.component';
import { ApproveSongRequestComponent } from './Features/radio-subsystem/song-requests/approve-song-request/approve-song-request.component';
import { RejectSongRequestComponent } from './Features/radio-subsystem/song-requests/reject-song-request/reject-song-request.component';
import { AddAdvertComponent } from './Features/radio-subsystem/crud-advert/add-advert/add-advert.component';
import { EditAdvertComponent } from './Features/radio-subsystem/crud-advert/edit-advert/edit-advert.component';
import { DeleteAdvertComponent } from './Features/radio-subsystem/crud-advert/delete-advert/delete-advert.component';
import { ViewAdvertsComponent } from './Features/radio-subsystem/crud-advert/view-adverts/view-adverts.component';
import { AddEventComponent } from './Features/radio-subsystem/crud-event/add-event/add-event.component';
import { EditEventComponent } from './Features/radio-subsystem/crud-event/edit-event/edit-event.component';
import { DeleteEventComponent } from './Features/radio-subsystem/crud-event/delete-event/delete-event.component';
import { ViewEventComponent } from './Features/radio-subsystem/crud-event/view-event/view-event.component';
import { AddNewsComponent } from './Features/radio-subsystem/crud-news/add-news/add-news.component';
import { DeleteArticleComponent } from './Features/radio-subsystem/crud-news/delete-article/delete-article.component';
import { EditArticleComponent } from './Features/radio-subsystem/crud-news/edit-article/edit-article.component';
import { ViewArticlesComponent } from './Features/radio-subsystem/crud-news/view-articles/view-articles.component';
import { AddShowComponent } from './Features/radio-subsystem/crud-show/add-show/add-show.component';
import { EditHowComponent } from './Features/radio-subsystem/crud-show/edit-how/edit-how.component';
import { EditShowsComponent } from './Features/radio-subsystem/crud-show/edit-shows/edit-shows.component';
import { DeleteShowsComponent } from './Features/radio-subsystem/crud-show/delete-shows/delete-shows.component';
import { DeleteShowComponent } from './Features/radio-subsystem/crud-show/delete-show/delete-show.component';
import { ViewShowsComponent } from './Features/radio-subsystem/crud-show/view-shows/view-shows.component';
import { EditShowComponent } from './Features/radio-subsystem/crud-show/edit-show/edit-show.component';


@NgModule({
  declarations: [
    PortalNavComponent,
    EcommerceDashboardComponent,
    RadioDashboardComponent,
    DiscountComponent,
    VatComponent,
    DeliveryComponent,
    AddColorComponent,
    ViewColorsComponent,
    DeleteColorsComponent,
    EditColorComponent,
    AddProductComponent,
    EditProductComponent,
    DeleteProductComponent,
    ViewProductsComponent,
    ViewProductCategoryComponent,
    EditProductCategoryComponent,
    AddProductCategoryComponent,
    DeleteProductCategoryComponent,
    AddProductTypeComponent,
    EditProductTypeComponent,
    DeleteProductTypeComponent,
    ViewProductTypesComponent,
    ViewSizesComponent,
    AddSizeComponent,
    EditSizeComponent,
    DeleteSizeComponent,
    ViewClientsComponent,
    PendingOrdersComponent,
    CompleteOrderComponent,
    OrderHistoryComponent,
    DeliverOrderComponent,
    ViewProfileComponent,
    UpdateProfileComponent,
    ViewUsersComponent,
    AddUserComponent,
    EditUserComponent,
    DeleteUserComponent,
    CrudEventComponent,
    CrudShowComponent,
    ViewMusicSubmissionComponent,
    ApproveMusicSubmissionComponent,
    RejectMusicSubmissionComponent,
    ViewSongRequestsComponent,
    ApproveSongRequestComponent,
    RejectSongRequestComponent,
    AddAdvertComponent,
    EditAdvertComponent,
    DeleteAdvertComponent,
    ViewAdvertsComponent,
    AddEventComponent,
    EditEventComponent,
    DeleteEventComponent,
    ViewEventComponent,
    AddNewsComponent,
    DeleteArticleComponent,
    EditArticleComponent,
    ViewArticlesComponent,
    AddShowComponent,
    EditHowComponent,
    EditShowsComponent,
    DeleteShowsComponent,
    DeleteShowComponent,
    ViewShowsComponent,
    EditShowComponent
  ],
  imports: [
    CommonModule,
    AdminPortalRoutingModule
  ]
})
export class AdminPortalModule { }
