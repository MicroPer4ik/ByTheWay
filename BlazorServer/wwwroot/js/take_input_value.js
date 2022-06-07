export function takeValues() {

    const values = Array.from(document.getElementsByClassName('inp_val')).map(inputEl => inputEl.value).join();
    return values;
    
}