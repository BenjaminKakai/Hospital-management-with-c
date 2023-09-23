import { Component } from '@angular/core';
import { RouterOutlet, RouterModule } from '@angular/router';
import { SecurityService } from "../security/shared/security.service";

@Component({
    templateUrl: "./fraction.component.html",
})
export class FractionComponent {
    validRoutes: any[] = [];
    public primaryNavItems: any[] = [];
    public secondaryNavItems: any[] = [];

    constructor(public securityService: SecurityService) {
        // Get the child routes of Inventory from valid routes available for this user.
        this.validRoutes = this.securityService.GetChildRoutes("Fraction");

        // Check if validRoutes is defined before filtering
        if (this.validRoutes) {
            this.primaryNavItems = this.validRoutes.filter(a => a.IsSecondaryNavInDropdown == null || a.IsSecondaryNavInDropdown == 0);
            this.secondaryNavItems = this.validRoutes.filter(a => a.IsSecondaryNavInDropdown == 1);
        }
    }
}

