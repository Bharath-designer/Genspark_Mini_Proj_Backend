## Fake Payment Gateway For EventManagement App

This is a fake payment gateway for EventManagemet App.

**To Install Dependencies**
```
npm run build
```

**To Run PaymentGateway**
```
npm start
```

**Endpoints**

- Create a Payment Session - ```{baseurl}/session [POST]```

        {
            "Amount": 100000,
            "Currency": "INR"
        }

- Payment Page - ```{baseurl}/payment/:transactionId [GET]```

