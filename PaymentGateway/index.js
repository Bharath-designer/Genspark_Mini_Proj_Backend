const express = require("express")
const axios = require("axios")
const { randomUUID: uuid } = require("crypto")
const app = express()
app.use(express.json())
app.set('view engine', 'ejs')

const _database = {
    API_KEY: "njk3-cs343-ccdscd",
    WEBHOOK_SECRET_KEY: "8a3a6e0967f0184db8a317910239ac2521a329783e2d88a1edeb3e",
    WEBHOOK_URL: "http://localhost:5232/api/payment/webhook", // EventManagement app's webhook url
    transactions: {
        "cdsf-32cds-23ecds-32cds": {
            TransactionId: "cdsf-32cds-23ecds-32cds",
            PaymentStatus: "PENDING",
            Amount: 3211,
            Currency: "INR",
            ExpiresAt: "1716851013000"  
        }
    }
}

const authenticationMiddleware = (req, res, next) => {
    const API_KEY = req.get("API_KEY")
    if (API_KEY != _database.API_KEY) {
        return res.status(401).json("Unauthorized")
    }
    next()
}

app.post("/session", authenticationMiddleware, (req, res) => {
    const transactionId = uuid()
    const { Amount, Currency } = req.body
    if (!Amount || !Currency) {
        res.status(400).json("Amount and Currency is Mandatory")
    }

    let ExpiryTime = new Date(new Date().getTime() + 8 * 60 * 1000)
    let temp = {
        TransactionId: transactionId,
        PaymentStatus: "PENDING",
        Amount: Amount,
        Currency: Currency,
        ExpiresAt: ExpiryTime.getTime()
    }
    _database.transactions[transactionId] = temp
    return res.json({
        TransactionId: transactionId,
        PaymentURL: `http://localhost:3500/payment/${temp.TransactionId}`,
        PaymentExpiresEpoch: temp.ExpiresAt
    })
})

app.get("/payment/:id", (req, res) => {
    const transactionId = req.params.id
    const sessionDetails = _database.transactions[transactionId]

    if (!sessionDetails) {
        return res.status(400).json("Invalid Payment URL")
    }

    res.render("index", sessionDetails)

})

app.post("/payment/:id/:status", async (req, res) => {
    try {
        const { id, status } = req.params

        if (_database.transactions[id].PaymentStatus != "PENDING") {
            return res.json("Transaction already completed")
        }

        if (status == "pay") {
            _database.transactions[id].PaymentStatus = "COMPLETED"

            let result = await fetch(_database.WEBHOOK_URL, {
                headers: {
                    "SECRET_KEY": _database.WEBHOOK_SECRET_KEY,
                    "Content-Type": "application/json"

                },
                method: "POST",
                body: JSON.stringify({
                    "TransactionId": id,
                    "PaymentStatus": "Completed",
                    "PaymentMethod": "Card"
                })
            })

            if (!result.ok) {
                console.log(result.status);
                throw new Error()
            }
            return res.redirect("http://localhost:3000/Profile.html?tab=orders")

        }

        _database.transactions[id].PaymentStatus = "FAILED"
        const result = await fetch(_database.WEBHOOK_URL, {
            headers: {
                "SECRET_KEY": _database.WEBHOOK_SECRET_KEY,
                "Content-Type": "application/json"
            },
            method: "POST",
            body: JSON.stringify({
                "TransactionId": id,
                "PaymentStatus": "Failed",
                "PaymentMethod": "Card"
            })
        })
        if (!result.ok) {
            console.log(result.status);
            throw new Error()
        }
        return res.redirect("http://localhost:3000/Profile.html?tab=orders")
    } catch (ex) {
        res.json("Internal server error")
        console.log(ex.message);
    }
})

app.get("/database", (req, res) => {
    res.json(_database)
})

app.listen(3500, () => {
    console.log("Server Started");
})