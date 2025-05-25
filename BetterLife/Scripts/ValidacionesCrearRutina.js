function validateRutinaLength(sender, args) {
    const value = args.Value.trim();
    args.IsValid = value.length >= 35 && value.length <= 4000;
}
