# Software Requirements Specification (SRS)

## Multi-Vendor Fashion E-Commerce Platform

**Version:** 1.7
**Status:** Prioritized Requirements Draft
**Document Type:** Functional and Non-Functional Requirements

---

## 1. Prioritization Method

Requirements are classified into three priority levels:

| Priority | Meaning | Target |
| --- | --- | --- |
| P0 — MVP | Essential for the first usable production release. | Initial release |
| P1 — Post-MVP | Important capabilities that can be introduced after the core marketplace is operational. | Subsequent releases |
| P2 — Future | Advanced capabilities and enhancements that are not required for the initial business launch. | Future releases |

Security, data integrity, and reliability requirements may be mandatory even
when they are not directly visible to users.

## 2. System Actors

| Actor | Description |
| --- | --- |
| Guest | Unauthenticated visitor who can browse publicly available products. |
| Consumer | Registered customer who can purchase products and manage orders. |
| Seller | Registered merchant who manages a store and sells products. |
| Verified Seller | Seller whose identity or business legitimacy has been verified. |
| Administrator | Platform operator responsible for platform configuration and management. |
| External ERP System | Seller-owned system that integrates with the marketplace through APIs. |
| Payment Provider | External payment service responsible for processing payments and payouts. |
| AI Services | Platform-provided AI capabilities. |

## 3. Functional Requirements — Prioritized

### Functional Requirements Priority Overview

| Rank | Requirement | Priority | MVP |
| ---: | --- | --- | --- |
| 1 | FR-01: Authentication and Authorization | P0 | Yes |
| 2 | FR-03: Seller Store Management | P0 | Yes |
| 3 | FR-04: Product and Variant Management | P0 | Yes |
| 4 | FR-05: Product Quantity Management | P0 | Yes, manual updates |
| 5 | FR-06: Consumer Shopping Experience | P0 | Yes |
| 6 | FR-07: Multi-Seller Checkout | P0 | Yes |
| 7 | FR-08: Payment and Financial Management | P0 | Yes, essential payment flow |
| 8 | FR-11: Order and Shipment Management | P0 | Yes, basic lifecycle |
| 9 | FR-16: Administrative Dashboard | P0 | Yes, essential controls |
| 10 | FR-02: Seller Registration and Verification | P0 | Basic verification |
| 11 | FR-10: Configurable Commission Management | P0 | Basic configurable rules |
| 12 | FR-12: Cancellation and Refund Policy | P0 | Basic cancellation policy |
| 13 | FR-09: Configurable Subscription Management | P1 | Free plan initially |
| 14 | FR-13: Seller API Integration | P1 | No |
| 15 | FR-14: AI-Powered Product and Outfit Search | P1 | No |
| 16 | FR-15: AI Virtual Try-On | P2 | No |

---

### FR-01: User Authentication and Authorization

**Priority:** P0 — MVP

The system shall:

1. Allow consumers and sellers to register and authenticate.
2. Support secure login and logout.
3. Support password recovery.
4. Provide role-based authorization.
5. Prevent users from accessing resources belonging to other users or sellers.
6. Support administrator accounts with privileged permissions.

**MVP scope:** Implement authentication, authorization, consumer accounts,
seller accounts, and administrator access.

### FR-02: Seller Registration and Verification

**Priority:** P0 — Basic verification in MVP

The system shall:

1. Allow sellers to register without requiring manual approval before accessing
   their dashboard.
2. Allow sellers to provide identity and business information.
3. Allow sellers to submit verification documents where required.
4. Provide an administrator interface for reviewing seller verification
   requests.
5. Support the following verification statuses:
   - Unverified
   - Pending
   - Verified
   - Rejected
   - Suspended
6. Allow administrators to approve or reject verification requests.
7. Record verification decisions and timestamps.
8. Allow administrators to request additional information.
9. Display seller verification status to consumers.
10. Distinguish seller registration from seller verification.

**MVP scope:**

- Seller registration.
- Basic business information.
- Verification status.
- Administrator review and approval/rejection.
- Display verification status.

Advanced automated verification providers and integrations can be introduced
later.

The business must decide whether unverified sellers can publish products and
accept orders.

### FR-03: Seller Store Management

**Priority:** P0 — MVP

The system shall allow sellers to:

1. Create and manage their stores.
2. Configure store names, descriptions, logos, and banners.
3. Manage store contact information.
4. View published products.
5. View orders and sales.
6. View subscription information.
7. View earnings and payout information.
8. Access store performance reports.

**MVP scope:** Store creation, basic store customization, product listing, order
visibility, and basic sales information.

Advanced analytics and performance reports can be introduced later.

### FR-04: Product and Variant Management

**Priority:** P0 — MVP

The system shall allow sellers to create and manage fashion products, including
shirts, T-shirts, trousers, jeans, jackets, dresses, and other clothing
categories.

Each product may contain:

1. Product name.
2. Description.
3. Category.
4. Brand.
5. Price.
6. Images.
7. Product status.
8. Available sizes.
9. Available colors.
10. SKU and external identifiers.
11. Product quantity or variant quantities.

For products with multiple sizes or colors, each variant shall maintain its own
quantity.

The total available product quantity may be calculated from active variants
rather than maintained as an independent conflicting value.

Sellers shall be able to:

- Create products.
- Update product information.
- Publish and unpublish products.
- Archive products.
- Create and manage variants.
- Update product quantities manually.
- Update quantities through the integration API.

**MVP scope:** Product CRUD, product images, categories, sizes, colors,
variants, pricing, and publishing.

External identifiers required specifically for ERP synchronization can be
expanded in P1.

### FR-05: Product Quantity Management

**Priority:** P0 — Manual quantity management in MVP

The platform shall support two quantity-update methods.

#### Manual Updates

Sellers can update product or variant quantities through their dashboard.

#### API Updates

External ERP systems can create products and update product information and
quantities through seller-specific API credentials.

Both methods shall update the same marketplace product and variant records.

The system shall:

1. Maintain marketplace quantities.
2. Record the source of quantity updates.
3. Record update timestamps.
4. Prevent negative quantities.
5. Apply transactional consistency.
6. Handle concurrent updates using database-level locking or equivalent
   concurrency control.
7. Prevent outdated updates from silently overwriting newer database state.

#### MVP Scope

- Manual product and variant quantity updates.
- Quantity validation.
- Stock deduction during successful order processing.
- Stock restoration for eligible cancellations.
- Prevention of duplicate stock changes.
- Basic concurrency protection.

#### Post-MVP Scope

- External ERP quantity synchronization.
- API-based product creation and updates.
- Advanced integration monitoring.

The platform does not replace the seller's external inventory-management system.

### FR-06: Consumer Shopping Experience

**Priority:** P0 — MVP

The system shall allow consumers to:

1. Browse products from multiple sellers.
2. Search and filter products.
3. Filter by category, seller, brand, size, color, and price.
4. View product details and images.
5. View seller information and verification status.
6. Add products to a shopping cart.
7. Purchase products from multiple sellers.
8. View order history.
9. Track order status.
10. Manage account information.

**MVP scope:** Product browsing, basic search, filtering, product details, cart,
checkout entry point, and order history.

Advanced AI search is not part of the initial release.

### FR-07: Multi-Seller Checkout

**Priority:** P0 — MVP

The system shall support purchasing products from multiple sellers in one
checkout process.

A multi-seller checkout shall:

1. Create one parent order.
2. Create separate seller-specific sub-orders.
3. Associate each sub-order with its corresponding seller.
4. Maintain product, quantity, and pricing details.
5. Track shipping and fulfillment separately where necessary.
6. Calculate platform commission and seller earnings.

**MVP scope:** One checkout, parent order, seller-specific sub-orders, and
consistent order totals.

### FR-08: Payment and Financial Management

**Priority:** P0 — Essential payment flow in MVP

The platform shall manage consumer payments through an integrated payment
provider.

The system shall:

1. Process consumer payments.
2. Record payment transactions.
3. Calculate platform commission.
4. Calculate seller earnings.
5. Maintain seller financial balances.
6. Support seller payouts through the configured payment provider.
7. Record payout transactions and statuses.
8. Maintain financial transaction history.
9. Support payment reconciliation.
10. Prevent duplicate financial processing.

**MVP scope:**

- Payment-provider integration.
- Payment confirmation.
- Payment status tracking.
- Commission calculation.
- Seller earnings calculation.
- Financial transaction records.

Advanced payout automation and reconciliation features may be phased in
depending on payment-provider capabilities.

### FR-09: Configurable Subscription Management

**Priority:** P1 — Post-MVP

The platform shall support:

- Free
- Premium
- Max

Subscription prices, billing periods, limits, and features shall be
administrator-configurable.

Administrators shall be able to configure:

1. Plan names.
2. Prices.
3. Billing periods.
4. Product limits.
5. API access permissions.
6. API usage limits.
7. Available seller features.
8. Activation and expiration rules.
9. Plan availability.
10. Plan-specific benefits.

**MVP scope:** Sellers can initially use the Free plan. The system should not
hardcode Premium or Max pricing or limits.

Full subscription billing, plan upgrades, and advanced plan enforcement are P1.

### FR-10: Configurable Commission Management

**Priority:** P0 — Basic configuration in MVP

The platform shall provide configurable commission rules.

Administrators shall be able to configure:

1. Default platform commission.
2. Seller-specific commission overrides.
3. Commission calculation method.
4. Commission applicability rules.
5. Effective dates.
6. Category-specific rules, if enabled.
7. Minimum or maximum commission constraints, if required.

Supported calculation strategies may include:

- Percentage of product subtotal.
- Fixed amount per transaction.
- Percentage plus fixed amount.
- Other supported administrator-configured strategies.

The default commission may start at 10%, but it is not a fixed business rule.

The system shall preserve the commission configuration and calculation result
applied to historical transactions.

**MVP scope:** Configurable default percentage, seller-specific override,
commission calculation, and transaction audit records.

Advanced category-specific rules and more complex commission strategies can be
added in P1.

### FR-11: Order and Shipment Management

**Priority:** P0 — Basic lifecycle in MVP

The system shall:

1. Create orders after successful checkout.
2. Create seller-specific sub-orders.
3. Allow sellers to process assigned orders.
4. Support shipment status updates.
5. Record shipment information.
6. Allow consumers to view order progress.
7. Support order receipt confirmation.
8. Maintain order status history.

Possible statuses:

- Pending
- Confirmed
- Processing
- Shipped
- Delivered
- Received
- Cancelled
- Refunded

**MVP scope:** Order creation, seller order management, status updates,
cancellation handling, shipment tracking information, and order history.

Advanced carrier integrations can be introduced later.

### FR-12: Cancellation and Refund Policy

**Priority:** P0 — Basic policy enforcement in MVP

The default business policy is that purchases are not generally refundable.

The system shall support configurable cancellation and refund rules.

Administrators shall be able to configure:

1. Cancellation period.
2. Return or refund period.
3. Product-category exclusions, such as underwear.
4. Product-condition requirements.
5. Eligibility for defective, damaged, or incorrect products.
6. Required evidence.
7. Refund approval permissions.

The system shall:

- Support order receipt confirmation.
- Prevent automatic refunds merely because an order is received.
- Support `Refunded` status when a refund actually occurs.
- Retain financial and order history.
- Avoid automatically restoring product quantity after a refund.

Stock restoration and refund processing shall remain separate operations.

**MVP scope:** Basic cancellation rules, status tracking, manual
exceptional-case handling, and correct stock behavior.

Advanced return workflows and configurable policy administration can be expanded
later.

### FR-13: Seller API Integration

**Priority:** P1 — Post-MVP

The platform shall provide secure APIs for seller-owned ERP systems.

#### API Authentication

Each seller shall be able to manage API credentials through the seller
dashboard.

API keys shall:

- Be unique to the seller.
- Be stored securely.
- Be displayed only when generated.
- Be revocable.
- Support rotation.
- Be scoped to the owning seller.

Authentication header:

`X-API-Key: {seller_api_key}`

#### API Key Management

| Method | Endpoint |
| --- | --- |
| POST | `/api/v1/seller/api-keys` |
| GET | `/api/v1/seller/api-keys` |
| GET | `/api/v1/seller/api-keys/{keyId}` |
| DELETE | `/api/v1/seller/api-keys/{keyId}` |
| POST | `/api/v1/seller/api-keys/{keyId}/rotate` |

These management endpoints require seller dashboard authentication.

#### Product Integration Endpoints

Base path: `/api/v1/seller-integration`

| Method | Endpoint |
| --- | --- |
| POST | `/api/v1/seller-integration/products` |
| GET | `/api/v1/seller-integration/products` |
| GET | `/api/v1/seller-integration/products/{productId}` |
| PUT | `/api/v1/seller-integration/products/{productId}` |
| PATCH | `/api/v1/seller-integration/products/{productId}` |
| DELETE | `/api/v1/seller-integration/products/{productId}` |

#### Variant Integration Endpoints

| Method | Endpoint |
| --- | --- |
| POST | `/api/v1/seller-integration/products/{productId}/variants` |
| GET | `/api/v1/seller-integration/products/{productId}/variants` |
| GET | `/api/v1/seller-integration/products/{productId}/variants/{variantId}` |
| PUT | `/api/v1/seller-integration/products/{productId}/variants/{variantId}` |
| PATCH | `/api/v1/seller-integration/products/{productId}/variants/{variantId}` |
| DELETE | `/api/v1/seller-integration/products/{productId}/variants/{variantId}` |

There shall be no separate inventory resource or inventory endpoints.

The API shall support HTTPS, JSON, versioning, pagination, validation,
idempotency, rate limiting, and OpenAPI documentation.

### FR-14: AI-Powered Product and Outfit Search

**Priority:** P1 — Post-MVP

The platform shall provide its own AI-powered search capability.

Consumers shall be able to describe their requirements using natural language.

Examples:

- "I need a casual outfit for summer."
- "Find a black shirt with blue jeans."
- "Show me a formal outfit under 2000 EGP."

The system shall:

1. Interpret natural-language requests.
2. Search actual marketplace products.
3. Recommend products that exist on the platform.
4. Consider availability, size, color, and budget.
5. Generate outfits using actual marketplace products.
6. Support outfits containing products from multiple sellers.
7. Avoid recommending fabricated or unavailable products.

#### AI Configuration

Administrators shall be able to configure:

- AI provider.
- AI model.
- Model version.
- Model configuration.
- Usage limits.
- Cost limits.
- Feature availability.

The maximum accepted AI request payload size shall be 3 MB.

The system shall track usage and estimated costs and enforce configured limits.

### FR-15: AI Virtual Try-On

**Priority:** P2 — Future

The platform shall provide Virtual Try-On functionality that allows consumers to
visualize clothing using a camera or uploaded image.

The feature shall:

1. Accept supported consumer image or camera input.
2. Allow product selection.
3. Generate a visual representation of the garment.
4. Display the generated result.
5. Allow consumers to try other supported products.

Virtual Try-On is a visual estimation and does not guarantee actual physical fit
or size.

Sellers must provide the garment assets required for the feature.

The provider, processing model, image storage, retention duration, deletion, and
consent policies remain configurable design decisions.

Consumer images shall not be used for AI training without separate explicit
consent.

### FR-16: Administrative Dashboard

**Priority:** P0 — Essential administration in MVP

The administrator shall be able to:

1. Manage users and sellers.
2. Review seller verification requests.
3. Suspend or reactivate sellers.
4. Manage product categories.
5. Configure basic commission rules.
6. Review orders and payments.
7. Review exceptional cancellation and refund cases.
8. Monitor basic platform activity.
9. Access basic financial reports.

**P1 additions:**

- Full subscription plan configuration.
- Advanced commission strategies.
- AI provider and model configuration.
- AI usage and cost monitoring.
- Advanced reporting and analytics.

---

## 4. Non-Functional Requirements — Prioritized

### Non-Functional Requirements Priority Overview

| Rank | Requirement | Priority | MVP |
| ---: | --- | --- | --- |
| 1 | NFR-02: Security | P0 | Yes |
| 2 | NFR-05: Data Integrity | P0 | Yes |
| 3 | NFR-14: Financial Accuracy and Auditability | P0 | Yes |
| 4 | NFR-04: Availability and Reliability | P0 | Yes |
| 5 | NFR-01: Performance | P0 | Yes |
| 6 | NFR-07: Privacy | P0 | Yes |
| 7 | NFR-08: Usability | P0 | Yes |
| 8 | NFR-11: Observability | P0 | Basic |
| 9 | NFR-13: Backup and Recovery | P0 | Yes |
| 10 | NFR-03: Scalability | P1 | Basic architecture only |
| 11 | NFR-06: API Quality | P1 | Basic internal APIs |
| 12 | NFR-09: Interoperability | P1 | External ERP integration |
| 13 | NFR-10: Maintainability | P0 | Yes |
| 14 | NFR-12: Accessibility | P1 | Basic accessibility in MVP |

### NFR-01: Performance

**Priority:** P0

1. Normal marketplace pages should load within acceptable response times.
2. Product search shall be optimized for responsive results.
3. API endpoints shall avoid unnecessary database queries.
4. AI processing shall be isolated from normal marketplace operations.
5. Long-running AI operations shall not block unrelated application requests.

**MVP focus:** Fast product browsing, cart operations, checkout, and order
processing.

### NFR-02: Security

**Priority:** P0 — Mandatory

1. All communication shall use HTTPS.
2. Passwords shall be securely hashed.
3. API keys shall be stored securely.
4. Role-based authorization shall protect resources.
5. Seller data shall be isolated.
6. Sensitive financial and personal data shall be protected.
7. Administrative operations shall be auditable.
8. File uploads shall be validated and protected against malicious content.

### NFR-03: Scalability

**Priority:** P1

The architecture shall support growth in:

- Sellers.
- Consumers.
- Product catalog size.
- Orders and transactions.
- API integration requests.
- AI processing demand.

The MVP shall use an architecture that does not prevent future scaling, but
advanced scaling infrastructure is not required at launch.

### NFR-04: Availability and Reliability

**Priority:** P0

1. Core shopping functions shall remain reliable.
2. Failed external integrations shall not corrupt marketplace data.
3. Payment and order operations shall prevent duplicate processing.
4. Critical operations shall support appropriate retry and recovery mechanisms.

### NFR-05: Data Integrity

**Priority:** P0 — Mandatory

1. Product quantities shall never become negative.
2. Financial calculations shall be consistent and auditable.
3. Order and payment records shall remain consistent.
4. Concurrent quantity updates shall use appropriate database concurrency
   controls.
5. Repeated order events shall not cause duplicate stock restoration.
6. Refund status shall not automatically restore sellable stock.

### NFR-06: API Quality

**Priority:** P1 for external seller integration

1. Integration APIs shall be versioned.
2. API documentation shall be maintained.
3. Error responses shall be consistent.
4. API authentication shall be secure.
5. Rate limiting shall protect the platform.
6. API behavior shall be backward-compatible within supported versions.

Basic internal API quality remains P0.

### NFR-07: Privacy

**Priority:** P0

1. Personal information shall be handled according to applicable privacy
   requirements.
2. Consumer images shall have controlled access.
3. Image retention and deletion shall follow configured policies.
4. Consumer images shall not be used for AI training without separate explicit
   consent.
5. Verification documents shall only be accessible to authorized personnel.

The MVP must protect personal and verification data even though Virtual Try-On
is deferred.

### NFR-08: Usability

**Priority:** P0

1. Seller dashboards shall be understandable.
2. Product creation shall support clothing-specific attributes.
3. Consumers shall navigate products and checkout efficiently.
4. The interface shall clearly display order and payment statuses.
5. The application shall provide understandable validation and error messages.

### NFR-09: Interoperability

**Priority:** P1

The platform shall support integration with seller-owned ERP systems through
documented REST APIs.

The MVP does not require external ERP integration.

### NFR-10: Maintainability

**Priority:** P0

1. The system shall use a modular architecture.
2. Business capabilities shall have clear boundaries.
3. Subscription prices and commission rules shall not be hardcoded.
4. AI capabilities shall be isolated behind service abstractions.
5. Configuration changes shall not require application code changes where
   configuration is specified.

### NFR-11: Observability

**Priority:** P0 — Basic monitoring

The platform shall record:

- Application errors.
- API requests.
- Quantity changes.
- Order status transitions.
- Payment transactions.
- Commission calculations.
- Administrative configuration changes.

Advanced AI usage and external integration monitoring can be added in P1.

### NFR-12: Accessibility

**Priority:** P1

The interfaces shall follow appropriate web accessibility practices.

The MVP should implement basic accessibility from the beginning, while a broader
accessibility review can be completed after launch.

### NFR-13: Backup and Recovery

**Priority:** P0

The platform shall maintain database backup and recovery procedures appropriate
for production data.

### NFR-14: Financial Accuracy and Auditability

**Priority:** P0 — Mandatory

1. Subscription charges, commissions, seller earnings, payments, and payouts
   shall be traceable.
2. Historical transactions shall preserve the financial rules applied when they
   were created.
3. Financial processing shall be protected against duplicate execution.
4. Monetary calculations shall use appropriate precision and rounding rules.

---

## 5. Business Rules

| ID | Rule |
| --- | --- |
| BR-01 | Each seller owns and manages their own store and products. |
| BR-02 | Seller registration does not require manual approval before dashboard access. |
| BR-03 | Seller verification is separate from registration. |
| BR-04 | The platform supports Free, Premium, and Max plans. |
| BR-05 | Subscription prices and limits are administrator-configurable. |
| BR-06 | The default commission may start at 10%, but is configurable. |
| BR-07 | Seller-specific commission overrides may be configured. |
| BR-08 | Subscription fees and transaction commissions are separate revenue streams. |
| BR-09 | The platform maintains marketplace quantities but does not replace external ERP inventory management. |
| BR-10 | Quantities can be updated manually or through the seller API. |
| BR-11 | Variants maintain separate quantities where size or color variations exist. |
| BR-12 | Product quantities must not become negative. |
| BR-13 | Successful purchases decrease the relevant quantity. |
| BR-14 | Eligible cancellations restore quantity only when the item is sellable. |
| BR-15 | A refunded order does not automatically increase product quantity. |
| BR-16 | Refunds are not generally available by default; exceptional eligibility rules require definition. |
| BR-17 | Multi-seller checkout creates one parent order and seller-specific sub-orders. |
| BR-18 | Platform commission is calculated according to configured rules. |
| BR-19 | AI recommendations must reference actual marketplace products. |
| BR-20 | AI request payloads must not exceed 3 MB. |
| BR-21 | AI provider, model, version, and cost limits are configurable. |
| BR-22 | Consumer images must not be used for AI training without separate explicit consent. |
| BR-23 | Concurrent quantity updates must use database concurrency control. |
| BR-24 | API keys must be scoped to their owning seller. |
| BR-25 | Financial and stock operations must be protected against duplicate event processing. |

---

## 6. System Architecture

The initial architecture shall follow a modular monolithic approach.

Suggested logical modules:

1. Identity and Access Management
2. Seller Management
3. Seller Verification
4. Store Management
5. Product Management
6. Seller API Integration
7. Shopping Cart and Checkout
8. Order Management
9. Payment Management
10. Subscription Management
11. Commission Management
12. AI Search
13. Virtual Try-On
14. Administration and Reporting

The initial release does not require a separate platform-owned
inventory-management module.

Product quantities are maintained as part of product and variant data.

Seller-owned ERP systems remain external.

AI features shall be implemented behind internal service abstractions.

---

## 7. MVP Scope

The first release shall focus on enabling the complete marketplace sales
lifecycle.

### Included in MVP

- [ ] Consumer authentication.
- [ ] Seller registration and authentication.
- [ ] Administrator authentication.
- [ ] Seller dashboard.
- [ ] Basic seller verification.
- [ ] Store creation and management.
- [ ] Product and variant CRUD.
- [ ] Product image management.
- [ ] Product categories.
- [ ] Manual quantity updates.
- [ ] Product browsing and filtering.
- [ ] Shopping cart.
- [ ] Multi-seller checkout.
- [ ] Payment integration.
- [ ] Parent orders and seller-specific sub-orders.
- [ ] Order status management.
- [ ] Basic shipment tracking.
- [ ] Basic cancellation handling.
- [ ] Correct stock deduction and restoration rules.
- [ ] Basic configurable commission.
- [ ] Seller earnings records.
- [ ] Basic administrator dashboard.
- [ ] Essential security, logging, backups, and monitoring.

### Excluded from MVP

- [ ] Premium and Max subscription billing.
- [ ] Advanced subscription plan management.
- [ ] External ERP integration.
- [ ] Seller API key management.
- [ ] Automatic ERP synchronization.
- [ ] AI-powered outfit search.
- [ ] AI Virtual Try-On.
- [ ] Advanced AI provider/model management.
- [ ] Advanced AI cost monitoring.
- [ ] Advanced seller analytics.
- [ ] Advanced automated seller verification.
- [ ] Advanced carrier integrations.
- [ ] Native mobile applications.

---

## 8. Suggested MVP Development Sequence

The following sequence is recommended to minimize dependencies and rework.

| Step | Development Area | Main Deliverables |
| ---: | --- | --- |
| 1 | Project Foundation | Architecture, database, configuration, logging, deployment foundation. |
| 2 | Identity | Consumer, seller, and administrator authentication and authorization. |
| 3 | Seller Management | Seller registration, store creation, basic verification. |
| 4 | Product Management | Categories, products, variants, images, and manual quantities. |
| 5 | Consumer Experience | Product listing, filtering, details, and shopping cart. |
| 6 | Order Management | Checkout, parent orders, seller sub-orders, order statuses. |
| 7 | Payments | Payment integration, commission calculation, seller earnings. |
| 8 | Stock Lifecycle | Quantity deduction, cancellation restoration, concurrency, idempotency. |
| 9 | Administration | Seller review, product categories, commission configuration, order monitoring. |
| 10 | Production Readiness | Security review, backups, monitoring, and acceptance testing. |

---

## 9. Acceptance Criteria for MVP

The MVP is ready for release when:

1. Multiple sellers can register and create independent stores.
2. Administrators can review and verify sellers.
3. Sellers can create products and variants.
4. Sellers can update quantities manually.
5. Consumers can browse products from multiple sellers.
6. Consumers can add products from different sellers to one cart.
7. The platform can create a parent order and seller-specific sub-orders.
8. Consumers can complete payment through the integrated payment provider.
9. The platform calculates commission and seller earnings correctly.
10. Purchases decrease the correct product or variant quantity.
11. Eligible cancellations restore sellable stock exactly once.
12. Refunded status does not automatically restore product quantity.
13. Sellers can manage their assigned orders.
14. Consumers can track their orders.
15. Administrators can configure the initial commission rules.
16. Seller data is isolated and protected.
17. Financial transactions and stock changes are auditable.
18. Production backups and monitoring are operational.

---

## 10. Financial Model Summary

The platform has two primary revenue streams.

### 10.1 Subscription Revenue

Supported plans:

- Free
- Premium
- Max

Premium and Max prices, billing periods, and features are configurable by
administrators.

The initial MVP may operate with the Free plan.

### 10.2 Transaction Commission

The platform earns commission from applicable sales.

Example:

| Item | Amount |
| --- | ---: |
| Product subtotal | 1,000 EGP |
| Example commission | 10% |
| Platform commission | 100 EGP |
| Seller amount before other deductions | 900 EGP |

The 10% value is illustrative and configurable.

---

## 11. Open Decisions

The following decisions must be finalized before implementing the corresponding
functionality:

| Decision | Status |
| --- | --- |
| Can unverified sellers publish and sell? | Open |
| What documents are required for seller verification? | Open |
| Which payment provider will be used? | Open |
| How and when are seller payouts executed? | Open |
| Is commission calculated before or after discounts, shipping, and taxes? | Open |
| What is the exact refund and 14-day policy? | Open |
| Which product categories are excluded from returns? | Open |
| When exactly is stock deducted during checkout and payment? | Requires order lifecycle review |
| How are damaged or unsellable cancelled products handled? | Agreed principle: do not restore sellable stock |
| Does the platform notify the ERP after sales and cancellations, or does the ERP poll for updates? | Open |
| Which Virtual Try-On provider will be used? | Open |
| What is the Virtual Try-On image retention policy? | Open |
| What are the Premium and Max plan prices and limits? | Administrator-configurable; values TBD |

---

## 12. Document Status

**Version 1.7** — Prioritized Requirements Draft

This document prioritizes requirements for the initial MVP and subsequent
releases.

P0 requirements define the minimum production-ready marketplace. P1 requirements
define important post-launch capabilities. P2 requirements define future
enhancements.

Priority does not remove mandatory security, privacy, financial integrity, or
reliability requirements.
