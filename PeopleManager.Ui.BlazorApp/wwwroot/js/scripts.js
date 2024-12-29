async function showAlert(dotNetRef, message) {
    alert(message);
    await dotNetRef.invokeMethodAsync('InvokeFromScript', 'This is a message that invokes C#')
    return "This is a message from our sponsor!";
}