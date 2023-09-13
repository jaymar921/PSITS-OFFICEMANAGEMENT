let api_globals = {
    api_link: ""
}

function SetApiGlobals(api_link) {
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
    return data;
}


async function PSITS_API_GetAllOfficeLogs(option, min = new Date(new Date().setHours(0, 0, 0, 0)).toISOString(), max = new Date().toISOString()) {
    const objHeader = {
        MinVal: min,
        MaxVal: max
    }

    if (option !== "") objHeader.option = option;

    const requestPayload = {
        method: "GET",
        credentials: "include",
        headers: {
            "Content-Type": "application/json",
            ...objHeader
        }
    }

    const res = await fetch(api_globals.api_link + "officelog", requestPayload);

    const { officeLogs } = await res.json();
    return { officeLogs };
}

async function PSITS_API_OfficeLogOff(){
    const requestPayload = {
        method: "PATCH",
        credentials: "include"
    }

    const res = await fetch(api_globals.api_link + "officelog", requestPayload);
    const StatusCode = await res.status;
    return StatusCode;
}


async function PSITS_API_OfficeLogIn(reason) {
    const requestPayload = {
        method: "POST",
        credentials: "include",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({remarks: reason})
    }

    const res = await fetch(api_globals.api_link + "officelog", requestPayload);

    const StatusCode = await res.status;
    return StatusCode;
}