let api_globals = {
    api_link: ""
}

function SetApiGlobals(api_link) {
    console.log(api_link)
    api_globals.api_link = api_link;
}

async function PSITS_API_Authenticate(rfid, password = undefined) {
    const payload = {
        rfid
    }

    if (password) payload.password = password;

    const requestPayload = {
        method: "POST",
        credentials: "include",
        headers: {
            "Content-Type":"application/json"
        },
        body: JSON.stringify(payload)
    }

    const res = await fetch(api_globals.api_link+"auth/login/rfid", requestPayload);
    const data = await res.json();
}